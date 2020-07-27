# Running Logic Apps Anywhere

Sandbox for playing with Azure Logic Apps which can now run anywhere.

## How to run it?

Build the app as a Docker image:
```shell
❯ docker build --tag logic-apps-anywhere --no-cache src
```

Run the Docker image:
```shell
❯ docker run -d -p 8080:80 -e "AzureWebJobsStorage=<connection-string>" logic-apps-anywhere
```

Run on Kubernetes:
```shell
❯ helm install logic-apps-anywhere-demo --set "secrets.functionStorage=<connection-string>" .\charts\logic-apps-anywhere-demo\
```

Get the callback URL to trigger the workflow via cURL:
```shell
❯ curl --location --request POST 'http://localhost:8080/runtime/webhooks/flow/api/management/workflows/StatefulSample/triggers/manual/listCallbackUrl?api-version=2019-10-01-edge-preview&code=<key>'
{
  "value": "https://localhost:443/api/StatefulSample/triggers/manual/invoke?api-version=2020-05-01-preview&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=<sig>",
  "method": "POST",
  "basePath": "https://localhost/api/StatefulSample/triggers/manual/invoke",
  "queries": {
    "api-version": "2020-05-01-preview",
    "sp": "/triggers/manual/run",
    "sv": "1.0",
    "sig": "<sig>"
  }
}
```

Trigger the workflow via cURL:
```shell
❯ curl --location --request POST 'http://localhost:8080/api/StatefulSample/triggers/manual/invoke?api-version=2020-05-01-preview&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=<sig>'
{
    "Message": "Hello from the workflow triggered function"
}
```