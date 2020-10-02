
class MM:

    def __init__(self):

        self.FLCVOffset = 0.0
        self.FRCVOffset = 0.0
        self.BRCVOffset = 0.0
        self.BLCVOffset = 0.0

        self.aPosPID = PID(1.0, 0.0, 0.0)
        self.bPosPID = PID(1.0, 0.0, 0.0)
        self.cPosPID = PID(1.0, 0.0, 0.0)
        self.yPosPID = PID(1.0, 0.0, 0.0)

    def processCVs(self):

        self.aPosPID.setSP(QCData.aPosSP);
        aPosCV = self.aPosPID.processCV(QCData.aPosPV);

        self.bPosPID.setSP(QCData.bPosSP);
        bPosCV = self.bPosPID.processCV(QCData.bPosPV);

        self.cPosPID.setSP(QCData.cPosSP);
        cPosCV = self.cPosPID.processCV(QCData.cPosPV);

        self.yPosPID.setSP(QCData.yPosSP);
        yPosCV = self.yPosPID.processCV(QCData.yPosPV);

        QCData.FRActCV = FRCVOffset - aPosCV + bPosCV - cPosCV + yPosCV;
        QCData.FLActCV = FLCVOffset - aPosCV - bPosCV + cPosCV + yPosCV;
        QCData.BRActCV = BRCVOffset + aPosCV + bPosCV + cPosCV + yPosCV;
        QCData.BLActCV = BLCVOffset + aPosCV - bPosCV - cPosCV + yPosCV;
