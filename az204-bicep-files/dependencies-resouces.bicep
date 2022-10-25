resource webApplication 'Microsoft.Web/sites@2021-01-15' = {
  name: 'name'
  location: 'eastus'
  tags: {
    'hidden-related:${resourceGroup().id}/providers/Microsoft.Web/serverfarms/appServicePlan': 'Resource'
  }
  properties: {
    serverFarmId: appServicePlan.id
  }
}

resource appServicePlan 'Microsoft.Web/serverfarms@2020-12-01' = {
  name: 'name'
  location: 'eastus'
  sku: {
    name: 'F1'
    capacity: 1
  }
}



