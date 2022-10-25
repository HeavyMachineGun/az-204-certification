param vmUserName string = 'someValues'
@secure()
param  vmPass string
@allowed([
  'windows'
  'linux'
])
@secure()
param system string = 'windows'
