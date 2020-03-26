# !/bin/bash

# Variables
commit_message=$1

ECHO ========================================================================================
ECHO = pushing to github dev branch
ECHO ========================================================================================

git checkout dev
git commit -m "$commit_message"