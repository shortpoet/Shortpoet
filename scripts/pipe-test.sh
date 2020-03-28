# !/bin/bash

# source config file
. test.conf

{
# Create a resource group.
echo =================================================================================
echo = Creating Resource group
echo =================================================================================
git status

# Create an App Service plan in STANDARD tier (minimum required by deployment slots).
echo =================================================================================
echo = Creating App Service Plan
echo =================================================================================
git status
# basic version of redirect anything within brackets is a capture group
} > ./logs/$target

# tee also shows output to console

# } | tee ./logs/$target

# appends

# } >> ./logs/$target
# } | tee -a ./logs/$target

# pipe will catch stdout only, 
# errors to stderr are not processed by the pipe with tee
# run command and redirect the stderr stream (2) to stdout (1)

# } 2>&1 | tee ./logs/$target
