
using EntityDB;
using EntityDB.Context;
using EntityDB.Entity;

var context = new RegistryContext();



var mockData = new DataGen();
mockData.GenerateAll();

