#define TURN_RATIO 45
#define TURN_DISTANCE 250
#define TURN_LEFT -340
#define TURN_RIGHT 400

#define L OUT_C
#define R OUT_A
#define LR OUT_AC
#define PWR_LR 50

//there are 8 lines on lcd so after 4th cmd lcd needs to be cleared or we can use ClearLine(LCD_LINE1);
task main() {
    //START CMD
    ClearScreen();
    TextOut(0, LCD_LINE1, "#0000");
    TextOut(0, LCD_LINE2, "START");

    //WAIT CMD
    ClearScreen();
    TextOut(0, LCD_LINE1, "#0001");
    TextOut(0, LCD_LINE2, "WAIT(1000)");
    Wait(1000);

    //FWD CMD
    ClearScreen();
    TextOut(0, LCD_LINE1, "#0002");
    TextOut(0, LCD_LINE2, "FWD(10cm)");
    RotateMotor(LR, PWR_LR, TURN_DISTANCE);

    //BACK CMD
    ClearScreen();
    TextOut(0, LCD_LINE1, "#0003");
    TextOut(0, LCD_LINE2, "BACK(10cm)");
    RotateMotor(LR, PWR_LR, TURN_DISTANCE);

    //TL CMD
    ClearScreen();
    TextOut(0, LCD_LINE1, "#0004");
    TextOut(0, LCD_LINE2, "< TL(45)");
    RotateMotor(LR, PWR_LR, TURN_DISTANCE);

    Wait(100);
    RotateMotorEx(LR, PWR_LR, TURN_LEFT, -TURN_RATIO, true, true);
    Wait(100);

    //TR CMD
    ClearScreen();
    TextOut(0, LCD_LINE1, "#0005");
    TextOut(0, LCD_LINE2, "> TR(45)");
    RotateMotor(LR, PWR_LR, TURN_DISTANCE);

    Wait(100);
    RotateMotorEx(LR, PWR_LR, TURN_LEFT, -TURN_RATIO, true, true);
    Wait(100);

    //FINISH CMD
    ClearScreen();
    TextOut(0, LCD_LINE1, "#0006");
    TextOut(0, LCD_LINE1, "FINISHED");
    Wait(10000);
}