#define TURN_RATIO 45

#define L OUT_C
#define R OUT_A
#define LR OUT_AC
#define PWR_LR 50

file has extenion nxc

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
    RotateMotor(LR, PWR_LR, 10 cm * 19.5);

    //BACK CMD
    ClearScreen();
    TextOut(0, LCD_LINE1, "#0003");
    TextOut(0, LCD_LINE2, "BACK(10cm)");
    RotateMotor(LR, PWR_LR, -10 cm * 19.5);

    //TL CMD
    ClearScreen();
    TextOut(0, LCD_LINE1, "#0004");
    TextOut(0, LCD_LINE2, "< TL(1)");

    Wait(100);
    RotateMotorEx(LR, PWR_LR, ((340 * 4) / 360) * angle [if angle < 0 ? LEFT : RIGHT], -TURN_RATIO, true, true);
    Wait(100);

    //TR CMD
    ClearScreen();
    TextOut(0, LCD_LINE1, "#0005");
    TextOut(0, LCD_LINE2, "> TR(1)");

    Wait(100);
    RotateMotorEx(LR, PWR_LR, TURN_LEFT, -TURN_RATIO, true, true);
    Wait(100);

    //FINISH CMD
    ClearScreen();
    TextOut(0, LCD_LINE1, "#0006");
    TextOut(0, LCD_LINE1, "FINISHED");
    Wait(10000);
}