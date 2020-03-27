# !/bin/bash

# Variables
commit_message=$1
gh="/h/source/repos/shortpoet.github.io"
sh="/h/source/repos/Shortpoet"



ECHO ========================================================================================
ECHO = initiating script with commit message $1
ECHO ========================================================================================

ECHO ========================================================================================
ECHO = switching to VueClient directory
ECHO ========================================================================================

# using full path to ensure proper capitalization for npm
cd $sh/Shortpoet/VueClient

ECHO ========================================================================================
ECHO = initiating npm build
ECHO ========================================================================================

npm run build

ECHO ========================================================================================
ECHO = switching to shortpoet directory
ECHO ========================================================================================

cd $sh

ECHO ========================================================================================
ECHO = pushing to github dev branch -- initiating azure pipeline
ECHO ========================================================================================

git checkout dev
git add .
git commit -m "$commit_message"
git push

ECHO ========================================================================================
ECHO = switching to github pages repo
ECHO ========================================================================================

cd $gh

ECHO ========================================================================================
ECHO = replacing items in github pages repo with dist folder contents
ECHO ========================================================================================

rm -rf img/ js/ css/ fonts/ index.html
cp -af ../shortpoet/Shortpoet/VueClient/dist/. .

ECHO ========================================================================================
ECHO = pushing to github pages master branch 
ECHO ========================================================================================

git checkout master
git add .
git commit -m "$commit_message"
git push

ECHO ========================================================================================
ECHO = switching back to shortpoet repo
ECHO ========================================================================================

cd $sh