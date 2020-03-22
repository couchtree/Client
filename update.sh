echo "Pull Client..."
git pull
git submodule update --init --recursive --remote
echo "Pull Illustrations.."
git submodule update --remote
