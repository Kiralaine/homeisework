using CQRSPlayer.APP.Dtos;
using CQRSPlayer.APP.Interfaces;
using MediatR;

namespace CQRSPlayer.APP.Queries;

public class GetAllPlayersHandler : IRequestHandler<GetAllPlayersQuery, ICollection<PlayerDto>>
{
    private readonly IPlayerReadRepository _playerReadRepository;

    public GetAllPlayersHandler(IPlayerReadRepository playerReadRepository)
    {
        _playerReadRepository = playerReadRepository;
    }

    public async Task<ICollection<PlayerDto>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
    {
        var players = await _playerReadRepository.GetAllAsync();
        var playersDtos = players.Select(p=>new PlayerDto()
        {
           
            FirstName = p.FirstName,
            LastName = p.LastName,
            Nationality = p.Nationality,
            Team = p.Team,
            Gender = p.Gender,
            Sport = p.Sport,
            Weight =  p.Weight,
            Height = p.Height,
            Position = p.Position,
            Age = p.Age
        }).ToList();
        return playersDtos;
    }
}