using Backend.Models;
using MongoDB.Driver;

namespace Backend.Services
{
    public class NotesDBService
    {
        private readonly IMongoCollection<NoteModel> _notesService;

        public NotesDBService(IMongoDatabase database)
        {
            _notesService = database.GetCollection<NoteModel>("NotesCollection");
        }

        public async Task CreateAsync(NoteModel data)
        {
            await _notesService.InsertOneAsync(data);
        }

       public async Task UpdateAsync(string id, NoteModel data)
        {
            var filter = Builders<NoteModel>.Filter.Eq("id", id); //query the element

            var update = Builders<NoteModel>.Update //update the element
                .Set(n => n.name, data.name)
                .Set(n => n.description, data.description);

            var updateOptions = new UpdateOptions { IsUpsert = false }; //do not insert

            var result = await _notesService.UpdateOneAsync(filter, update, updateOptions); //update the element by the new update version

          
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<NoteModel>.Filter.Eq("id", id); // Create a filter to match the document by id

            var deleteOptions = new DeleteOptions { }; // Create delete options (if any specific options are needed)

            var result = await _notesService.DeleteOneAsync(filter, deleteOptions); // Delete the matching document

            // Additional code or handling based on the result
        }

        public async Task<List<NoteModel>> GetNotes ()
        {
             var filter = Builders<NoteModel>.Filter.Empty; // Filter to match all documents

             var notes = await _notesService.Find(filter).ToListAsync(); // Retrieve all documents matching the filter

             return notes;
        }

    }
}
