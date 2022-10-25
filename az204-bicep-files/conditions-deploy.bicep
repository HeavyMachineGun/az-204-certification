@description('Number of storage account to be deployed')
param storageCount int

@allowed([
  'new'
  'existing'
])
@description('Specify whether to deploy new Storage Accounts or if the Storage Accounts are already existing')
param newOrExistingStgAcnt string

var location = resourceGroup().location
var baseName = toLower(uniqueString(resourceGroup().id))

resource storageaccount 'Microsoft.Storage/storageAccounts@2021-02-01' = [for i in range(1,storageCount): if(newOrExistingStgAcnt == 'new'){
    name: '${i}st${baseName}'
    location: location
    kind: 'StorageV2'
    sku: {
      name: 'Premium_LRS'
    }
  }]

