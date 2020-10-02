
class PID:

    def __init__(self, dt, KP, KI, KD):

        self.KP = KP
        self.KI = KI
        self.KD = KD

        self.dt = dt

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
        return self.ER

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
