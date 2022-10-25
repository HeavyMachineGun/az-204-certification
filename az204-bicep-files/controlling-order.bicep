var location = resourceGroup().location
var baseName = toLower(uniqueString(resourceGroup().id))

//example of separate dependant resources
resource webApplication 'Microsoft.Web/sites@2021-01-15' = {
  name: 'webapp${baseName}'
  location: location
  tags: {
    'hidden-related:${resourceGroup().id}/providers/Microsoft.Web/serverfarms/appServicePlan': 'Resource'
  }
  properties: {
    serverFarmId: appServicePlan.id
  }
}

resource appServicePlan 'Microsoft.Web/serverfarms@2020-12-01' = {
  name: 'appsrvplan${baseName}'
  location: location
  sku: {
    name: 'F1'
    capacity: 1
  }
}

//example of parent and child resources nested within the parent resource

resource storageaccount1 'Microsoft.Storage/storageAccounts@2021-02-01' = {
  name: 'storageAccount${baseName}'
  location: location
  kind: 'StorageV2'
  sku: {
    name: 'Premium_LRS'
  }
  resource blob 'blobServices' = {
    name: 'default'

    resource container1 'containers' = {
      name: 'nestedcontainer'
    }

  }
}

//example of parent and child resources in separate resources

resource storageaccount2 'Microsoft.Storage/storageAccounts@2021-02-01' = {
  name: 'straccount2${baseName}'
  location: location
  kind: 'StorageV2'
  sku: {
    name: 'Premium_LRS'
  }
}

resource blob2 'Microsoft.Storage/storageAccounts/blobServices@2022-05-01' = {
  name: 'default'
  parent: storageaccount2
}

resource container 'Microsoft.Storage/storageAccounts/blobServices/containers@2022-05-01' = {
  name: 'acontainer'
  parent: blob2
}
