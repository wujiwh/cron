@echo off
REM =============================================================================
REM      FileName: Setup.bat
REM          Desc: 
REM        Author: WangHeng
REM         Email: me@wangheng.org
REM      HomePage: http://wangheng.org
REM       Version: 0.0.1
REM    LastChange: 2012-06-08 09:53:03
REM       History:
REM =============================================================================
if exist c:\cron (echo Cron install.log stored at c:\cron\) else mkdir c:\cron
echo Install Cron Started at [%time:~0,5%]. >>c:\cron\install.log
install.exe Cron.exe >>c:\cron\install.log
echo Install Finished at [%time:~0,5%] ! >>c:\cron\install.log
echo on
echo Finished.
pause
