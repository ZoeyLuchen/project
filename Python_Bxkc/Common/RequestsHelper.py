import requests

def get(url,params={},encoding=""):
    headers = {
        "user-agent": "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.33 Safari/537.36"};
    req = requests.get(url, headers=headers, params=params)
    if encoding != "":
        req.encoding = encoding;
    return req;

def getAsync(url,params={},encoding=""):
    headers = {
        "user-agent": "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.33 Safari/537.36",
        "x-requested-with": "XMLHttpRequest"};
    req = requests.get(url, headers=headers, params=params)
    if encoding != "":
        req.encoding = encoding;
    return req;

def post( url, datas={}, encoding=""):
    headers = {
        "user-agent": "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.33 Safari/537.36"};
    req = requests.post(url, headers=headers, datas=datas)
    if encoding != "":
        req.encoding = encoding;
    return req;

def postAsync( url, data={}, encoding=""):
    headers = {
        "user-agent": "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.33 Safari/537.36",
        "x-requested-with": "XMLHttpRequest"};
    req = requests.post(url, headers=headers, data=data)
    if encoding != "":
        req.encoding = encoding;
    return req;