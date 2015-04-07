#comma reader
#enter number of commas expected per line
def findNumberCommasPerLine(numberOfCommasPerLine, filename):
    linenumber = 0
    errorLines = []

    with open(filename, 'r') as f:
        for line in f:
            linenumber = linenumber + 1
            numCommas = line.count(',')
            if not numCommas == numberOfCommasPerLine:
                errorLines.append(linenumber)


    print("Error lines: ")
    print(errorLines)
    print("Number of errors: {0}".format(len(errorLines)))
