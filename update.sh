echo "Pull Client..."
git pull
git submodule update --init --recursive
echo "Pull Illustration..."
cd StayAtHome-Client/Assets/Sprites/Illustrations
git pull
