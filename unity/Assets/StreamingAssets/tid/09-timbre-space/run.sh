#!/bin/bash

filebase="colorsounds"
export filebase
function analyze()
{
	local idx=$1
	pd -nogui -send "; \
continue 1; \
full-sample-mode 0; \
max-sample-length 970200; \
window-size 16484; \
db-thresh 40; \
save-text ${filebase}-${idx}-a.txt; \
filenames-list ${filebase}-${idx}.txt; \
;" -open ./lib/audio-patch.pd

}
export -f analyze


parallel analyze ::: 1 2 3 4