using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using System.Web.Mvc;
using MongoDB.Bson.IO;
using MongoDB.Driver.Builders;
using Newtonsoft.Json;

namespace AngularMVC.DbUtil
{
    public class DbUtility
    {
        protected MongoDatabase mongoDB { get; set; }
        public DbUtility()
        {
            var mongoClient = new MongoClient(Convert.ToString(ConfigurationManager.AppSettings["MongoDBServer"]));
            MongoServer Server = mongoClient.GetServer();
            mongoDB = Server.GetDatabase(Convert.ToString(ConfigurationManager.AppSettings["DBName"]));
        }
        /// <summary>
        /// It saves single document to the collection
        /// </summary>
        /// <param name="objectToSave"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public bool SaveDocument(string objectToSave, string collectionName)
        {
            var document = BsonSerializer.Deserialize<BsonDocument>(objectToSave);
            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            collection.Insert(document);
            return true;
        }
        /// <summary>
        /// It saves single document to the collection and returns its ObjectId
        /// </summary>
        /// <param name="objectToSave"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public string SaveDocumentAndReturnObjectId(string objectToSave, string collectionName)
        {
            var document = BsonSerializer.Deserialize<BsonDocument>(objectToSave);
            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            collection.Insert(document);
            return document["_id"].ToString();
        }

        /// <summary>
        /// It saves Multiple  documents to the collection
        /// </summary>
        /// <param name="objectToSave"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public bool SaveDocuments(string objectsToSave, string collectionName)
        {
            List<BsonDocument> documents = BsonSerializer.Deserialize<List<BsonDocument>>(objectsToSave);
            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            collection.InsertBatch(documents);
            return true;
        }
        /// <summary>
        /// It replaces a  single document to the collection by the key and its value
        /// </summary>
        /// <param name="objectToSave"></param>
        /// <param name="collectionName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ReplaceDocument(string objectToSave, string collectionName, string key, string value)
        {

            var document = BsonSerializer.Deserialize<BsonDocument>(objectToSave);
            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            collection.Update(
            Query.EQ(key, value),
            Update.Replace(document),
            UpdateFlags.None);
            return true;
        }
        /// <summary>
        /// It replaces a  single document to the collection by the key and its value
        /// </summary>
        /// <param name="objectToSave"></param>
        /// <param name="collectionName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ReplaceDocument(string objectToSave, string collectionName, string key, int value)
        {

            var document = BsonSerializer.Deserialize<BsonDocument>(objectToSave);
            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            collection.Update(
            Query.EQ(key, value),
            Update.Replace(document),
            UpdateFlags.None);
            return true;
        }
        /// <summary>
        /// It replaces a  single document to the collection by ObjectId , so send the object with object id in it.
        /// </summary>
        /// <param name="objectToSave"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public bool ReplaceDocumentByObjectId(string objectToSave, string collectionName)
        {

            var document = BsonSerializer.Deserialize<BsonDocument>(objectToSave);
            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            collection.Save(document);
            return true;
        }
        /// <summary>
        /// Updates and appends All documents of the collection. Key is the attribute to be updated by the Value
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="key"> Attribute</param>
        /// <param name="value">Attribute value</param>
        /// <returns></returns>
        public bool UpdateAllDocuments(string collectionName, string key, string value)
        {
            BsonValue bsonvalue = BsonSerializer.Deserialize<BsonValue>(value);
            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            collection.Update(Query.Exists(key), Update.Set(key, bsonvalue), UpdateFlags.Multi);
            return true;
        }
        /// <summary>
        /// Updates and appends multiple documents of the collection. Id and its Idvalue is the where condition and  Key is the attribute to be updated by the Value
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="IdValue"></param>
        /// <param name="collectionName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool UpdateDocumentsById(string Id, int IdValue, string collectionName, string key, string value)
        {
            BsonValue bsonvalue = BsonSerializer.Deserialize<BsonValue>(value);
            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            collection.Update(Query.EQ(Id, IdValue), Update.Set(key, bsonvalue), UpdateFlags.Multi);
            return true;
        }
        /// <summary>
        /// Updates and appends multiple documents of the collection. Id and its Idvalue is the where condition and  Key is the attribute to be updated by the Value
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="IdValue"></param>
        /// <param name="collectionName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool UpdateDocumentsById(string Id, string IdValue, string collectionName, string key, string value)
        {
            BsonValue bsonvalue = BsonSerializer.Deserialize<BsonValue>(value);
            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            collection.Update(Query.EQ(Id, IdValue), Update.Set(key, bsonvalue), UpdateFlags.Multi);
            return true;
        }
        /// <summary>
        /// Updates and appends multiple documents of the collection by ObjectId.IdValue is the ObjectId value, Key is the attribute to be updated by the Value
        /// </summary>
        /// <param name="IdValue"></param>
        /// <param name="collectionName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool UpdateDocumentsByObjectId(string IdValue, string collectionName, string key, string value)
        {
            BsonValue bsonvalue = BsonSerializer.Deserialize<BsonValue>(value);
            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            collection.Update(Query.EQ("_id", ObjectId.Parse(IdValue)), Update.Set(key, bsonvalue), UpdateFlags.Multi);
            return true;
        }
        /// <summary>
        /// Updates and appends multiple documents of the collection by Id with multiple update Attributes.IdValue is the Id value, Key is the attribute to be updated by the Value
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="IdValue"></param>
        /// <param name="collectionName"></param>
        /// <param name="objectToSave"></param>
        /// <returns></returns>
        public bool UpdateDocumentsByIdForMultipleAttributes(string Id, string IdValue, string collectionName, string objectToSave)
        {
            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            Dictionary<string, BsonValue> keyvalues = BsonSerializer.Deserialize<Dictionary<string, BsonValue>>(objectToSave);
            var updateValues = new List<UpdateBuilder>();
            foreach (var item in keyvalues)
            {
                updateValues.Add(Update.Set(item.Key, item.Value));
            }
            IMongoUpdate update = Update.Combine(updateValues);
            collection.Update(Query.EQ(Id, IdValue), update, UpdateFlags.Multi);
            return true;
        }
        /// <summary>
        /// Updates and appends multiple documents of the collection by Id with multiple update Attributes.IdValue is the Id value, Key is the attribute to be updated by the Value
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="IdValue"></param>
        /// <param name="collectionName"></param>
        /// <param name="objectToSave"></param>
        /// <returns></returns>
        public bool UpdateDocumentsByIdForMultipleAttributes(string Id, int IdValue, string collectionName, string objectToSave)
        {
            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            Dictionary<string, BsonValue> keyvalues = BsonSerializer.Deserialize<Dictionary<string, BsonValue>>(objectToSave);
            var updateValues = new List<UpdateBuilder>();
            foreach (var item in keyvalues)
            {
                updateValues.Add(Update.Set(item.Key, item.Value));
            }
            IMongoUpdate update = Update.Combine(updateValues);
            collection.Update(Query.EQ(Id, IdValue), update, UpdateFlags.Multi);
            return true;
        }
        /// <summary>
        /// Updates and appends multiple documents of the collection by ObjectId with multiple update Attributes.IdValue is the ObjectId value, Key is the attribute to be updated by the Value
        /// </summary>
        /// <param name="IdValue"></param>
        /// <param name="collectionName"></param>
        /// <param name="objectToSave"></param>
        /// <returns></returns>
        public bool UpdateDocumentsByObjectIdForMultipleAttributes(string IdValue, string collectionName, string objectToSave)
        {
            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            Dictionary<string, BsonValue> keyvalues = BsonSerializer.Deserialize<Dictionary<string, BsonValue>>(objectToSave);
            var updateValues = new List<UpdateBuilder>();
            foreach (var item in keyvalues)
            {
                updateValues.Add(Update.Set(item.Key, item.Value));
            }
            IMongoUpdate update = Update.Combine(updateValues);
            collection.Update(Query.EQ("_id", ObjectId.Parse(IdValue)), update, UpdateFlags.Multi);
            return true;
        }
        /// <summary>
        /// Updates documents for List of Ids ....["Id1","Id2"] and updates the key by its value
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="IdValues"></param>
        /// <param name="collectionName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool UpdateDocumentsByIds(string Id, string IdValues, string collectionName, string key, string value)
        {
            BsonValue bsonvalue = BsonSerializer.Deserialize<BsonValue>(value);
            List<BsonValue> values = BsonSerializer.Deserialize<List<BsonValue>>(IdValues);
            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            collection.Update(Query.In(Id, values), Update.Set(key, bsonvalue), UpdateFlags.Multi);
            return true;

        }
        /// <summary>
        /// Updates documents for List of ObjectIds ....["ObjectId1","ObjectId2"] and updates the key by its value
        /// </summary>
        /// <param name="IdValues"></param>
        /// <param name="collectionName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool UpdateDocumentsByObjectIds(string IdValues, string collectionName, string key, string value)
        {
            BsonValue bsonvalue = BsonSerializer.Deserialize<BsonValue>(value);
            List<BsonValue> values = BsonSerializer.Deserialize<List<BsonValue>>(IdValues);
            for (int i = 0; i < values.Count(); i++)
            {
                values[i] = ObjectId.Parse(values[i].ToString());
            }

            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            collection.Update(Query.In("_id", values), Update.Set(key, bsonvalue), UpdateFlags.Multi);
            return true;

        }
        /// <summary>
        /// Deletes a document by Object Id
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteDocumentByObjectId(string collectionName, String Objectid)
        {
            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            var query = Query.EQ("_id", ObjectId.Parse(Objectid));
            collection.Remove(query);
            return true;
        }
        /// <summary>
        /// Deletes a document by Id
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="key"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteDocumentById(string collectionName, string key, string id)
        {
            var collection = mongoDB.GetCollection<BsonDocument>(collectionName);
            var query = Query.EQ(key, id);
            collection.Remove(query);
            return true;
        }
        /// <summary>
        /// Gets All the Documents for the collection without ObjectId
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public string GetAllDocuments(string collectionName)
        {
            var collection = mongoDB.GetCollection(collectionName);
            return collection.FindAllAs<BsonDocument>().SetFields(Fields.Exclude("_id")).ToJson();
        }
        /// <summary>
        /// Gets All the Documents for the collection with ObjectId
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public string GetAllDocumentsWithObjectId(string collectionName)
        {
            var collection = mongoDB.GetCollection(collectionName);
            var jsonSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            return collection.FindAllAs<BsonDocument>().ToJson(jsonSettings);
        }
        /// <summary>
        /// Gets All the Documents for the collection without ObjectId by Id 
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetDocumentsById(string collectionName, string key, string value)
        {
            var jsonSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            var collection = mongoDB.GetCollection(collectionName);
            var query = Query.EQ(key, value);
            return collection.FindAs<BsonDocument>(query).SetFields(Fields.Exclude("_id")).ToJson(jsonSettings);
        }
        /// <summary>
        /// Gets All the Documents for the collection without ObjectId by ObjectId
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetDocumentByObjectId(string collectionName, string key, string value)
        {
            var jsonSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            var collection = mongoDB.GetCollection(collectionName);
            var query = Query.EQ(key, ObjectId.Parse(value));
            return collection.FindAs<BsonDocument>(query).SetFields(Fields.Exclude("_id")).ToJson(jsonSettings);
        }
        /// <summary>
        /// Gets All the Documents for the collection with ObjectId by Id 
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetDocumentByIdWithObjectId(string collectionName, string key, string value)
        {
            var jsonSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            var collection = mongoDB.GetCollection(collectionName);
            var query = Query.EQ(key, value);
            return collection.FindAs<BsonDocument>(query).ToJson(jsonSettings);
        }
        /// <summary>
        /// Gets  Document from the collection with ObjectId by ObjectId 
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetDocumentByObjectIdWithObjectId(string collectionName, string key, string value)
        {
            var jsonSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            var collection = mongoDB.GetCollection(collectionName);
            var query = Query.EQ(key, ObjectId.Parse(value));
            return collection.FindAs<BsonDocument>(query).ToJson(jsonSettings);
        }
        /// <summary>
        /// Returns the Collection
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public MongoCollection GetCollection(string collectionName)
        {
            return mongoDB.GetCollection(collectionName);
        }
        /// <summary>
        /// Gets the Document count for a collection
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public long GetCountOfCollection(string collectionName)
        {
            var collection = mongoDB.GetCollection(collectionName);
            return collection.Count();
        }
        /// <summary>
        /// Gets the Max of a given Attribute for a Collection
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="attributename"></param>
        /// <returns></returns>
        public long GetMaxOfAttribute(string collectionName, string attributename)
        {
            var collection = mongoDB.GetCollection(collectionName);
            var max = collection.FindAll().SetSortOrder(SortBy.Descending(attributename)).SetLimit(1).FirstOrDefault().ToArray()[1].Value.ToInt64();
            return max;
        }

        public string GetDocumentByMultipleAttributes(string collectionName, string Searchobject)
        {
            var jsonSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            Dictionary<string, BsonValue> keyvalues = BsonSerializer.Deserialize<Dictionary<string, BsonValue>>(Searchobject);
            List<IMongoQuery> queries = new List<IMongoQuery>();
            foreach (var item in keyvalues)
            {
                queries.Add(Query.EQ(item.Key, item.Value));
                
            }
            IMongoQuery mongoQuery = Query.And(queries);
            var collection = mongoDB.GetCollection(collectionName);
            return collection.FindAs<BsonDocument>(mongoQuery).ToJson(jsonSettings);

        }
        public string GetDocumentsByQuery(string collectionName, string query)
        {
            var jsonSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            QueryDocument mongoquery = new QueryDocument(BsonDocument.Parse(query));
            
            var collection = mongoDB.GetCollection(collectionName);
            return collection.FindAs<BsonDocument>(mongoquery).ToJson(jsonSettings);
           

        }

    }
}