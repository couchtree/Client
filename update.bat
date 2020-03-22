@echo off
cd %HOME%
echo "Pull Client..."
git pull
git submodule update --init --recursive
echo "Pull Illustration..."
git submodule update