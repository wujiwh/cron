@echo off
REM =============================================================================
REM      FileName: unstall.bat
REM          Desc: 
REM        Author: WangHeng
REM         Email: me@wangheng.org
REM      HomePage: http://wangheng.org
REM       Version: 0.0.1
REM    LastChange: 2012-06-08 09:52:31
REM       History:
REM =============================================================================
echo Unstall Cron Started at [%time:~0,5%].
sc stop cron
install.exe /u Cron.exe >>c:\cron\install.log.
echo Unstall Finished at [%time:~0,5%] !
echo on 
echo Finished.
pause
