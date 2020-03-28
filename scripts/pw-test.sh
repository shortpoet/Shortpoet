# !/bin/bash

# https://unix.stackexchange.com/questions/35088/reading-passwords-without-showing-on-screen-in-bash-scripts
# https://unix.stackexchange.com/questions/212329/hiding-password-in-shell-scripts/212363#212363

. dev.config

echo $url
echo "UN => $UN"
echo "PW => $PW"

echo -n "USERNAME: "; read uname
echo -n "PASSWORD: "; stty -echo; read passwd; stty echo; echo
echo $uname $passwd
passwd= # get rid of passwd
echo "##" $uname $passwd " ##"