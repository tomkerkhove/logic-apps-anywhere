# Running Logic Apps Anywhere

Sandbox for playing with Azure Logic Apps which can now run anywhere.

## How to run it?

Build the app as a Docker image:
```
❯ docker build --tag logic-apps-anywhere --no-cache src
```

Run the Docker image:
```
❯ docker run -d -p 8080:80 logic-apps-anywhere -e "AzureWebJobsStorage=<connection-string>"
```
