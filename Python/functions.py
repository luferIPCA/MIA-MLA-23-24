
#by lufer
#add two numbers
def addNumbers(a, b):
    return a + b

def subNumbers(a,b): return a-b


import datetime

def getCurrentTime():
    current_time = datetime.datetime.now()
    formatted_time = current_time.strftime("%Y-%m-%d %H:%M:%S")
    return formatted_time