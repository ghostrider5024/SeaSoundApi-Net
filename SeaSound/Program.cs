using SeaSound.Data;
using SeaSound.Repository;
using SeaSound.Repository.IRepository;
using SeaSound.Service;
using SeaSound.Service.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add DI
AddDI(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void AddDI(IServiceCollection services)
{
    #region Song
    services.AddScoped<ISongRepository, SongRepository>();
    services.AddScoped<ISongService, SongService>();
    #endregion

    #region Album
    services.AddScoped<IAlbumRepository, AlbumRepository>();
    services.AddScoped<IAlbumService, AlbumService>();
    #endregion

    //#region Artist
    //services.AddScoped<ArtistRepository>();
    //services.AddScoped<IArtistService, ArtistService>();
    //#endregion

    //#region SongArtist
    //services.AddScoped<SongArtistRepository>();
    //services.AddScoped<ISongArtistService, SongArtistService>();
    //#endregion

    services.AddAutoMapper(typeof(Program).Assembly);
}