
pushd ../ConsoleRobot

(echo place 1,2,SOUTH &^
 echo report &^
 dir^
 ) | ConsoleRobot.exe

popd
pause