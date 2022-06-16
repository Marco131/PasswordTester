#!/bin/bash
clear

# password input
HASPRESSEDENTER=false
PASSWORD=""
echo -n "write : "
until $HASPRESSEDENTER; do
	read -s -n1 char

	if [[ $char = "" ]]; then
	HASPRESSEDENTER=true
	else
	echo -n "*"
	PASSWORD+=$char
	fi
done
echo ""
echo $PASSWORD
