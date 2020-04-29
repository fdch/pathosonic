#!/bin/sh

# Convert to html
pandoc -f latex -t html -s pathosonic.tex --css pandoc.css --bibliography=pathosonic.bib -o index.html

# See html file
open index.html

# Make pdf
pdflatex -interaction=nonstopmode pathosonic.tex > /tmp/log
bibtex pathosonic > /tmp/biblog
pdflatex -interaction=nonstopmode pathosonic.tex > /tmp/log
pdflatex -interaction=nonstopmode pathosonic.tex > /tmp/log

echo "cat /tmp/{log,biblog} for latex compilation errors and warnings"
exit