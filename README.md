# Running Logic Apps Anywhere

Sandbox for playing with Azure Logic Apps which can now run anywhere.

## How to run it?

Build the app as a Docker image:
```
❯ docker build --tag logic-apps-anywhere --no-cache src
```

Run the Docker image:
```
❯ docker run -d -p 8080:80 -e "AzureWebJobsStorage=<connection-string>" logic-apps-anywhere
```

Run on Kubernetes:
```
helm install logic-apps-anywhere-demo --set "secrets.functionStorage=<connection-string>" .\charts\logic-apps-anywhere-demo\
```