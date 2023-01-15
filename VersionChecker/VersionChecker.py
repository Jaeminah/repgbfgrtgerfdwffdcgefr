import requests, json
from bs4 import BeautifulSoup

def main():
    response = requests.get("https://github.com/Jaeminah/repgbfgrtgerfdwffdcgefr/tags")
    soup = BeautifulSoup(response.text, "html.parser")
    latest = soup.find_all("a", {"class":"Link--primary"})[0]
    with open("./bin/RemakeVersion.txt", "r") as remakeVersion:
        if (remakeVersion.read() == latest.text):
            output = {
                "Github": {
                    "Latest Version": latest.text,
                    "Release Link": f"https://github.com{latest['href']}"
                },
                "Message": "You're up to date",
                "Status": "1"
            }
        else:
            output = {
                "Github": { 
                    "Latest Version": latest.text,
                    "Release Link": f"https://github.com{latest['href']}"
                },
                "Message": "You're not up to date",
                "Status": "0"
            }

        json_object = json.dumps(output, indent=4)

        with open("./bin/VersionCheck.json", "w") as output:
            output.write(json_object)

if __name__ == "__main__":
    try:
        main()
    except Exception as e:
        print(str(e))
