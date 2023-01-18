# DroneApi 
Web Api  with Asp.Net Core


Drones management
Only 10 drones can be registered
Drones that are in a state of delivering or returning cannot be loaded with medicines.

service to register a drone  url:  post:http://api/drone json:
{
  "model": "string",
  "weightLimit": 500,
  "batteryCapacity": 0,
  "state": "string",
  "serialNumber": "string",
  "image": "string base 64"
}
service to get all drone  url:  get:https://api/drone
you can filter get:http://api/drone?WithMedication=true&SerialNumber=ass&Model=Lightweight&State=IDLE

service to get all drone  url:  get:https://api/drone
you can filter get:http://api/drone?WithMedication=true&SerialNumber=ass&Model=Lightweight&State=IDLE

service to update one drone url:  put:https:///api/drone/{id}  json:
{
  "model": "string",
  "weightLimit": 500,
  "batteryCapacity": 0,
  "state": "string",
  "serialNumber": "string",
  "image": "string base 64"
}
service to delete one drone url:  delete:https://api/drone/{id} 

service to get medications of one drone     url:get: https://localhost:7285/api/drone/getmedications/{droneid}

service to push one medication in one drone    url post:https:///api/drone/loadmedication/{droneid}  json: 
{
    "name": "string",
    "weight": 0,
    "code": "string"
  }
  service to push medications in one drone    url post:https:///api/drone/loadmedication/{droneid}  json: 
{
   [
   {"name": "string",
    "weight": 0,
    "code": "string"
    }
    ]
  }
 service to get battery logs  of one drone get: https:///api/drone/getbatterylogs/{id}
 
  service to get battery logs  of all drones get: https:///api/drone/getbatterylogs
   service to clear battery logs  of all drones delete: https:///api/drone/getbatterylogs
   
   
