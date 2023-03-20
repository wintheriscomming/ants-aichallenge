@echo off
set /p "launchDebugger=Launch debugger (y or n)?"
python ../tools/playgame.py "dotnet run" "python ../tools/sample_bots/python/HunterBot.py" --map_file ../tools/maps/example/tutorial1.map --log_dir game_logs --turns 60 --scenario --food none --player_seed 7 -e --turntime 3600000 --loadtime 3600000