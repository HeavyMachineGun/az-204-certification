resource storageaccount 'Microsoft.Storage/storageAccounts@2021-02-01' = {
  name: 'account1'
  location: 'eastus'
  kind: 'StorageV2'
  sku: {
    name: 'Premium_LRS'
  }
}

resource blobbicepaccount 'Microsoft.Storage/storageAccounts/blobServices@2022-05-01' = {
  name: 'default'
  parent: storageaccount
}


resource contaner1w 'Microsoft.Storage/storageAccounts/blobServices/containers@2022-05-01' = {
  name: 'mybicepcontainer'
  parent: blobbicepaccount

}
