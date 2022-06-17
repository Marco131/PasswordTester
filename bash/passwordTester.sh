#!/bin/bash
clear

# read character file into array
readarray -t pwCharArray < characters.txt

# function that checks if a character is in pwCharArray
# Argument: character to test
# Returns: 1 if the array contains the char, else 0
isCharInArray () {
	local charToTest="$1"

	for item in "${pwCharArray[@]}"
	do
		if [[ "$item" = "$charToTest"* ]]; then
		return  1
		fi
	done

	return 0
}

# password input
HASPRESSEDENTER=false
PASSWORD=""
echo -n "Enter a password : "
until $HASPRESSEDENTER; do
	read -s -n1 char

	if [[ $char = "" ]]; then	# if char is enter 
		HASPRESSEDENTER=true
	elif [[ $char = $'\177' ]] && [ ! -z $PASSWORD ]; then	# if char is backspace
		PASSWORD=${PASSWORD::-1} # remove last character from password

		# rewrite input
		clear
		echo -n "Enter a password : "
		echo $PASSWORD | awk -v ORS="" '{ gsub(/./,"&\n") ; print }' | \
		while read char
		do
			echo -n "*"
		done
	else
		isCharInArray "$char"
		if [ $? -eq 1 ]; then
			echo -n "*"
			PASSWORD+=$char
		fi
	fi
done
echo ""