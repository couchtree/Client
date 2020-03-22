@echo off
cd %HOME%
echo "Pull Client..."
git pull
git submodule update --init --recursive
echo "Pull Illustration..."
cd StayAtHome-Client\Assets\Sprites\Illustration
git pull origin master