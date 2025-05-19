# Azure functions workshop demo

Local setup with azurite and Azure Service Bus emulator

## Prerequisites

- [Docker](https://www.docker.com/get-started/) or [Rancher Desktop](https://rancherdesktop.io/)
- [dotnet-sdk](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) 9.0 or later

### sqlcmd

```bash
curl https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -
curl https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/prod.list | sudo tee /etc/apt/sources.list.d/msprod.list

sudo apt-get update
sudo apt-get install mssql-tools unixodbc-dev

echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc
source ~/.bashrc
```
