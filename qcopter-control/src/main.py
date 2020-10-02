import json
import pandas as pd
from flask import Flask, request, Response
from flask_socketio import SocketIO, emit


app = Flask(__name__)
app.config['SECRET_KEY'] = '1234'
socketio = SocketIO(app, logger=True)



# GET requests use params to specify which resource is gonna be read
# try GET localhost:3000/app/v2/930djf43jkdf02
@app.route('/app/<paramVersocketion>/<paramId>', methods = ['GET'])
def get_task_by_params(paramVersocketion, paramId):

    obj = json.loads('{}')
    obj['versocketion'] = paramVersocketion
    obj['id'] = paramId
    str = json.dumps(obj)
    socketio.emit('onSetup', {})    
    return Response(str, status = 200, mimetype = 'application/json')

@socketio.on('connect')
def connect():
    print('connected')
    socketio.emit('onConnect', {})
    return True

@socketio.on('stream')
def stream(in_dic):
    #print(in_dic)
    out_dic = behave(in_dic)

    #xVel = in_dic['S07']
    #th = out_dic['TH']    
    #print(xVel,',', th,',')

    socketio.emit('onStream', out_dic)

@socketio.on('disconnect')
def disconnect():
    print('disconnected')
    socketio.emit('onDisconnect', {})
    return True








class PID:

    def __init__(self, KP, KI, KD):

        self.KP = KP
        self.KI = KI
        self.KD = KD

        self.P = 0.0
        self.I = 0.0
        self.D = 0.0

        self.lastPV = 0.0
        self.lastER = 0.0
        self.SP = 0.0

    def getSP(self):
        return self.SP

    def setSP(self, SP):
        self.SP = SP

    def getER(self):
        return self.lastER

    def processCV(self, PV, dt):

        self.PV = PV
        self.ER = self.SP - self.PV

        self.P = self.KP * self.ER
        self.I = self.I + self.KI * ((self.ER + self.lastER)*(dt/2.0))
        self.D = self.KD * (self.lastPV - self.PV);

        self.CV = self.P + self.I + self.D
        self.lastPV = self.PV
        self.lastER = self.ER

        return self.CV



FLCVOffset = 49.4
FRCVOffset = 49.4
BRCVOffset = 49.4
BLCVOffset = 49.4

xPosPID = PID(1.0, 0.0, 0.0)
xVelPID = PID(1000.0, 0.0, 50000.0)

zPosPID = PID(1.0, 0.0, 0.0)
zVelPID = PID(1000.0, 0.0, 50000.0)

yPosPID = PID(15.0, 0.5, 200.0)
yawPosPID = PID(5.0, 0.0, 150.0)



xPosPID.setSP(0.0)
xVelPID.setSP(0.0)

zPosPID.setSP(0.0)
zVelPID.setSP(0.0)

yPosPID.setSP(1.0)
yawPosPID.setSP(0.0)

curr_wp = 0

def update_sp(curr_pos):

    global curr_wp

    global xPosPID
    global yPosPID
    global zPosPID
    global yawPosPID



    pos0 = (0.0, 1.0, 0.0, -45.0)
    pos1 = (1.2, 1.0, -1.2, -45.0)
    tolerance_radio = 0.05

    if(curr_wp == 0):
        print('STATE 0')
        xPosPID.setSP(pos0[0])
        yPosPID.setSP(pos0[1])
        zPosPID.setSP(pos0[2])
        yawPosPID.setSP(pos0[3])        
        if(pos0[0] - tolerance_radio <= curr_pos[0] and curr_pos[0] <= pos0[0] + tolerance_radio):
            if(pos0[1] - tolerance_radio <= curr_pos[1] and curr_pos[1] <= pos0[1] + tolerance_radio):            
                if(pos0[2] - tolerance_radio <= curr_pos[2] and curr_pos[2] <= pos0[2] + tolerance_radio):
                    if(pos0[3] - 0.1 <= curr_pos[3] and curr_pos[3] <= pos0[3] + 0.1):
                        curr_wp = 1
                        print('0')

    elif(curr_wp == 1):
        xPosPID.setSP(pos1[0])
        yPosPID.setSP(pos1[1])
        zPosPID.setSP(pos1[2])
        yawPosPID.setSP(pos1[3])   
        if(pos1[0] - tolerance_radio <= curr_pos[0] and curr_pos[0] <= pos1[0] + tolerance_radio):
            if(pos1[1] - tolerance_radio <= curr_pos[1] and curr_pos[1] <= pos1[1] + tolerance_radio):
                if(pos1[2] - tolerance_radio <= curr_pos[2] and curr_pos[2] <= pos1[2] + tolerance_radio):
                    if(pos1[3] - 0.1 <= curr_pos[3] and curr_pos[3] <= pos1[3] + 0.1):
                        curr_wp = 0
                        print('1')

def behave(in_dic):
  
    #update_sp((in_dic['S04'], 1.0, in_dic['S06'], in_dic['S03']))
    print(in_dic['S04'])
    print(in_dic['S06'])
    print(in_dic['S03'])
    print('')
      
    global xPosPID
    xPosCV = xPosPID.processCV(in_dic['S04'], in_dic['S01'])
    global xVelPID
    xVelPID.setSP(xPosCV)
    xVelCV = xVelPID.processCV(in_dic['S07'], in_dic['S01'])

    global zPosPID
    zPosCV = zPosPID.processCV(in_dic['S06'], in_dic['S01'])
    global zVelPID
    zVelPID.setSP(zPosCV)
    zVelCV = zVelPID.processCV(in_dic['S05'], in_dic['S01'])

    global yawPosPID
    yawPosCV = yawPosPID.processCV(in_dic['S03'], in_dic['S01'])
    
    global yPosPID
    yPosCV = yPosPID.processCV(in_dic['S02'], in_dic['S01'])
    
    out_dic = {
        'A01': FRCVOffset - xVelCV + zVelCV - yawPosCV + yPosCV,
        'A02': FLCVOffset - xVelCV - zVelCV + yawPosCV + yPosCV, 
        'A03': BRCVOffset + xVelCV + zVelCV + yawPosCV + yPosCV,
        'A04': BLCVOffset + xVelCV - zVelCV - yawPosCV + yPosCV,
        'TH': xVelCV
    }
    
    return out_dic


#pid01 = PID(15.0, 0.5, 150.0)
#pid01.setSP(0.4)

#def behave(in_dic):
#    global pid01
#    cv = pid01.processCV(in_dic['S02'], in_dic['S01'])
#    cv = cv + 49.4
#    #print(cv)
#    out_dic = {
#        'A01': cv,
#        'A02': cv, 
#        'A03': cv,
#        'A04': cv
#    }
#    return out_dic




if __name__ == '__main__':
    socketio.run(app, port=4567, debug=True)






