# -- coding utf-8 --
import json
import os

def hw():
    path = os.getcwd() + "/Assets/Save/"
    with open(path + 'playerInfo_123.json') as obj:
        line = obj.read()
        content = json.loads(line)
    print(content["tipStates"][0]["quizID"])
 
 
if __name__ == '__main__':
    hw()