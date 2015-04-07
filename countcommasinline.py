#comma reader
def findNumberCommas():
    print("enter file name:")
    filename = input()
    #print("enter number of commas to match:")
    #numCommas = input()

    linenumber = 0
    numCommas = 0
    errorLines = []

    with open(filename, 'r') as f:
        for line in f:
            linenumber = linenumber + 1
            tempNumCommas = line.count(',')
            if not tempNumCommas == 16:
                errorLines.append(linenumber)


    print("Error lines: ")
    print(errorLines)
    print("Number of errors:")
    print(len(errorLines))
