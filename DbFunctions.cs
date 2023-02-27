using Microsoft.EntityFrameworkCore;
using WardrobeWizardDb.Models;
using WardrobeWizardDb;

internal class DbFunctions
{
    private DBActions dbAction = new DBActions();

    public async Task PrintOutfitsOfUser1Async()
    {
        string connStr = dbAction.GetConnectionString("WardrobeWizardDb");
        var contextOptions = new DbContextOptionsBuilder<WardrobeWizardContext>()
            .UseSqlServer(connStr)
            .Options;

        using (var context = new WardrobeWizardContext(contextOptions))
        {
            var outfitsOfUser1 = await context.Outfits
                .Where(o => o.UserId == 1)
                .ToListAsync();

            foreach (var outfit in outfitsOfUser1)
            {
                Console.WriteLine($"Outfit {outfit.OutfitId} for User 1: {outfit.Name}");
            }
        }
        public void AddItem(Item item, int userId)
        {
          using (SqlConnection connection = new SqlConnection(connectionString))
         {
         string sql = "INSERT INTO items (itemId,userId, category, color, style, brand, image_url) VALUES (@item_id, @user_id, @category, @color, @style, @brand, @image_url)";
         SqlCommand command = new SqlCommand(sql, connection);
                 command.Parameters.AddWithValue("@itemId", item.item_id);
                 command.Parameters.AddWithValue("@category", item.category);
                 command.Parameters.AddWithValue("@color", item.color);
                 command.Parameters.AddWithValue("@style", item.style);
                 command.Parameters.AddWithValue("@brand", item.brand);
                 command.Parameters.AddWithValue("@imageUrl", item.image_url);
                 command.Parameters.AddWithValue("@userId", userId);
         connection.Open();
         command.ExecuteNonQuery();
        }
         }
        public void UpdateItem(Item item,int userId )
        {
         using (SqlConnection connection = new SqlConnection(connectionString))
         {
          connection.Open();

          SqlCommand command = new SqlCommand("UPDATE Item SET Category = @category, Color = @color, Style =@style, Brand = @brand, ImageUrl = @imageUrl WHERE ItemId = @itemId AND UserId = @userId", connection);
          command.Parameters.AddWithValue("@category", item.category);
          command.Parameters.AddWithValue("@color", item.color);
          command.Parameters.AddWithValue("@style", item.style);
          command.Parameters.AddWithValue("@brand", item.brand);
          command.Parameters.AddWithValue("@color", item.color);
          command.Parameters.AddWithValue("@imageUrl", item.imageUrl);
          command.Parameters.AddWithValue("@itemId", item.itemId);
          command.Parameters.AddWithValue("@userId", userId );
          
          command.ExecuteNonQuery();
        }
         }
        public void DeleteItem(Item item, int userId, int itemId)
        {
         using (SqlConnection connection = new SqlConnection(connectionString))
    {
         connection.Open();

          SqlCommand command = new SqlCommand("DELETE FROM Item WHERE ItemId = @itemId AND UserId = @userId", connection);
          command.Parameters.AddWithValue("@category", item.category);
          command.Parameters.AddWithValue("@color", item.color);
          command.Parameters.AddWithValue("@style", item.style);
          command.Parameters.AddWithValue("@brand", item.brand);
          command.Parameters.AddWithValue("@color", item.color);
          command.Parameters.AddWithValue("@imageUrl", item.imageUrl);
          command.Parameters.AddWithValue("@itemId", itemId);
          command.Parameters.AddWithValue("@userId", userId );
          command.ExecuteNonQuery();
    }
}


        public void AddUser(User user, int userId, int measurementsId)
        {
          using (SqlConnection connection = new SqlConnection(connectionString))
         {
         string sql = "INSERT INTO User (userId, name, age, gender, email, phone, password, measurementsId) VALUES (@userId, @name, @age, @gender, @email, @phone, @password, @measurementsId)";
         SqlCommand command = new SqlCommand(sql, connection);
                 command.Parameters.AddWithValue("@userId", userId);
                 command.Parameters.AddWithValue("@name", user.name);
                 command.Parameters.AddWithValue("@age", user.age);
                 command.Parameters.AddWithValue("@gender", user.gender);
                 command.Parameters.AddWithValue("@email", user.email);
                 command.Parameters.AddWithValue("@phone", user.phone);
                 command.Parameters.AddWithValue("@password", user.password);
                 command.Parameters.AddWithValue("@measurementsId", measurementsId);
         connection.Open();
         command.ExecuteNonQuery();
        }
         }
        public void UpdateUser(User user,int userId)
        {
         using (SqlConnection connection = new SqlConnection(connectionString))
         {
          connection.Open();

          SqlCommand command = new SqlCommand("UPDATE User SET Name = @name, Age =@age, Gender = @gender, Email = @email, Phone = @phone, Password = @password MeasurementsId = @measurementsId WHERE UserId = @userId", connection);
          command.Parameters.AddWithValue("@name", user.name);
          command.Parameters.AddWithValue("@age", user.age);
          command.Parameters.AddWithValue("@gender", user.gender);
          command.Parameters.AddWithValue("@email", user.email);
          command.Parameters.AddWithValue("@phone", user.phone);
          command.Parameters.AddWithValue("@password", user.password);
          command.Parameters.AddWithValue("@userId", userId);
          command.Parameters.AddWithValue("@measurementsId", user.MeasurementsId);

          command.ExecuteNonQuery();
        }
         }
        public void AddMeasurement(Measurement measurement, int measurementsId)
        {
          using (SqlConnection connection = new SqlConnection(connectionString))
          {
           connection.Open();

          SqlCommand command = new SqlCommand("INSERT ITO Measurement (height, weight, waist, bust, hip, size, measurementsId) VALUES (@height, @weight, @waist, @bust, @hip, @size, @measurementsId);
          command.Parameters.AddWithValue("@height", measurement.height);
          command.Parameters.AddWithValue("@weight", measurement.weight);
          command.Parameters.AddWithValue("@waist", measurement.waist);
          command.Parameters.AddWithValue("@bust", measurement.bust);
          command.Parameters.AddWithValue("@hip", measurement.hip);
          command.Parameters.AddWithValue("@size", measurement.size);
          command.Parameters.AddWithValue("@measurementsId", measurementsId);

          command.ExecuteNonQuery();
          }
        }

        public void UpdateMeasurement(Measurement measurement, int measurementsId)
        {
          using (SqlConnection connection = new SqlConnection(connectionString))
          {
           connection.Open();

          SqlCommand command = new SqlCommand("UPDATE Measurement SET Height = @height, Weight = @weight, Waist =@waist, Bust = @bust, Hip = @hip, Size = @size WHERE MeasurementsId = @measurement_id", connection);
          command.Parameters.AddWithValue("@height", measurement.height);
          command.Parameters.AddWithValue("@weight", measurement.weight);
          command.Parameters.AddWithValue("@waist", measurement.waist);
          command.Parameters.AddWithValue("@bust", measurement.bust);
          command.Parameters.AddWithValue("@hip", measurement.hip);
          command.Parameters.AddWithValue("@size", measurement.size);
          command.Parameters.AddWithValue("@measurementsId", measurementsId);

          command.ExecuteNonQuery();
          }
        }
        
        public void DeleteMeasurement(Measurement measurement, int measurementsId)
        {
          using (SqlConnection connection = new SqlConnection(connectionString))
          {
           connection.Open();

          SqlCommand command = new SqlCommand("DELETE FROM Measurement WHERE MeasurementsId = @measurementsId", connection);
          command.Parameters.AddWithValue("@height", measurement.height);
          command.Parameters.AddWithValue("@weight", measurement.weight);
          command.Parameters.AddWithValue("@waist", measurement.waist);
          command.Parameters.AddWithValue("@bust", measurement.bust);
          command.Parameters.AddWithValue("@hip", measurement.hip);
          command.Parameters.AddWithValue("@size", measurement.size);
          command.Parameters.AddWithValue("@measurementsId", measurementsId);

          command.ExecuteNonQuery();
          }
        }

         public void addOutfit(Outfit outfit, int userId, int itemId1,?int itemId2, ?int itemId3, ?int itemId4 )
         {
          using (SqlConnection connection = new SqlConnection(connectionString))
          {
          string sql = "INSERT INTO Outfit (userId, itemId1, itemId2,itemId3, itemId4, outfitId, name, description) VALUES (@userId, @itemId1, @itemId2, @itemId3, itemId4, @outfitId, @name, @description)";
          SqlCommand command = new SqlCommand(sql, connection);
                 command.Parameters.AddWithValue("@outfitId", outfit.outfitId);
                 command.Parameters.AddWithValue("@name", outfit.name);
                 command.Parameters.AddWithValue("@description", outfit.description);
                 command.Parameters.AddWithValue("@userId" ,userId);
                 command.Parameters.AddWithValue("@itemId1" ,itemId1);
                 command.Parameters.AddWithValue("@itemId2" ,itemId2);
                 command.Parameters.AddWithValue("@itemId3" ,itemId3);
                 command.Parameters.AddWithValue("@itemId4" ,itemId4);
          connection.Open();
          command.ExecuteNonQuery();
          }
         }
        public void UpdateOutfit(Outfit outfit, int userId, int outfitId)
        {
          using (SqlConnection connection = new SqlConnection(connectionString))
          {
           connection.Open();

          SqlCommand command = new SqlCommand("UPDATE Outfit SET ItemId1 = @ItemId1,itemId2 = @itemId2, ItemId2 = @itemId2, ItemId3 = @itemId3, ItemId4 = @itemId4, Name =@name, Description = @description WHERE OuttfitId = @outfitId AND UserId = @userID", connection);
          command.Parameters.AddWithValue("@name", outfit.name);
          command.Parameters.AddWithValue("@description", outfit.description);
          command.Parameters.AddWithValue("@outfitId", outfitId);
          command.Parameters.AddWithValue("@userId" ,userId);
          command.Parameters.AddWithValue("@itemId1" ,outfit.itemId1);
          command.Parameters.AddWithValue("@itemId2" ,outfit.itemId2);
          command.Parameters.AddWithValue("@itemId3" ,outfit.itemId3);
          command.Parameters.AddWithValue("@itemId4" ,outfit.itemId4);
          command.ExecuteNonQuery();
          }
        
        }        
        public void DeleteOutfit(Outfit outfit, int userId, int outfitId)
        {
          using (SqlConnection connection = new SqlConnection(connectionString))
          {
           connection.Open();

          SqlCommand command = new SqlCommand("DELETE FROM Outfit WHERE UserId = @userId AND OutfitId = @outfitId", connection);
          command.Parameters.AddWithValue("@name", outfit.name);
          command.Parameters.AddWithValue("@description", outfit.description);
          command.Parameters.AddWithValue("@outfitId", outfit.outfitId);
          command.Parameters.AddWithValue("@userId" ,userId);
          command.Parameters.AddWithValue("@itemId1" ,outfit.itemId1);
          command.Parameters.AddWithValue("@itemId2" ,outfit.itemId2);
          command.Parameters.AddWithValue("@itemId3" ,outfit.itemId3);
          command.Parameters.AddWithValue("@itemId4" ,outfit.itemId4)
          command.ExecuteNonQuery();
          }
        
        }        
    }
}
