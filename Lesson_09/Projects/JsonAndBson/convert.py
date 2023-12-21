import bson
import json

with open("sampledata.json", "r") as f:
    json_data = json.load(f)

bson_data_list = [bson.dumps(item) for item in json_data]

with open("output.bson", "wb") as f:
    for bson_item in bson_data_list:        
        f.write(bson_item)

json_data_read = [bson.loads(bson_item) for bson_item in bson_data_list]

with open("output.bson", "rb") as f:
    bson_data = f.read()
    print(repr(bson_data))

print()

print(json_data_read)
