from flask import Flask

app = Flask(__name__, static_folder="static")


@app.route("/")
def home():
    return app.send_static_file("index.html")


if __name__ == "__main__":
    app.run(host="127.0.0.1", port=5000)
