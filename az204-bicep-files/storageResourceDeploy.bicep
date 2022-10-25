resource storageaccount1 'Microsoft.Storage/storageAccounts@2021-02-01' = {
  name: 'nestorbicepfile'
  location: 'eastus'
  kind: 'StorageV2'
  sku: {
    name: 'Premium_LRS'
  }
  properties: {
    supportsHttpsTrafficOnly: true   
  }
}
