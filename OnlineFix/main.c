#include <stdio.h>
#include <stdlib.h>
int main()
{
    char answer;
    printf("\n\t\t\tWannaSmile v1.0 - Protect yourself from WannaCry Ransomware\n\n ");
    printf("\n\t This will do the following");
    printf("\n\t 1. Disable SMB ( which is enabled by default)");
    printf("\n\t 2. Add Google's ip to kill-switch (which stops the ransomware from infecting)");
    printf("\n\n \tTHIS IS A TEMPORARY SOLUTION");
    printf("\n \tPLEASE UPDATE YOUR WINDOWS  ASAP TO PATCH (MS17-010)");
    printf("\n\n\tWould you like to make the changes ? Press enter to confirm: ", answer);
    scanf("%c", &answer);
    {


    system("powershell.exe Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters\" SMB1 -Type DWORD -Value 0 -Force");
    system("powershell.exe Set-ItemProperty -Path \"HKLM:\\SYSTEM\\CurrentControlSet\\Services\\LanmanServer\\Parameters\" SMB2 -Type DWORD -Value 0 -Force");

    char link[200]="\n216.58.197.132 www.iuqerfsodp9ifjaposdfjhgosurijfaewrwergwea.com";
    char link1[200]="\n216.58.197.132 iuqerfsodp9ifjaposdfjhgosurijfaewrwergwea.com";
    char link2[200] ="\n216.58.197.132 www.ifferfsodp9ifjaposdfjhgosurijfaewrwergwea.com";
    char link3[200] ="\n216.58.197.132 ifferfsodp9ifjaposdfjhgosurijfaewrwergwea.com";
    char link4[200] ="\n216.58.197.132 www.iuqssfsodp9ifjaposdfjhgosurijfaewrwergwea.com";
    char link5[200] ="\n216.58.197.132 iuqssfsodp9ifjaposdfjhgosurijfaewrwergwea.com";
    char link6[200] ="\n216.58.197.132 www.ayylmaotjhsstasdfasdfasdfasdfasdfasdfasdf.com";
    char link7[200] ="\n216.58.197.132 ayylmaotjhsstasdfasdfasdfasdfasdfasdfasdf.com";

    FILE *fptr;

    fptr = fopen("C:\\Windows\\System32\\drivers\\etc\\hosts", "a");

    fprintf(fptr,"%s", link);
    fprintf(fptr,"%s", link1);
    fclose(fptr);
    exit(0);
    }
    return 0;
}
