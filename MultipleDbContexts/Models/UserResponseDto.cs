namespace MultipleDbContexts.Models
{
    public record struct UserResponseDto(
        int Id, 
        string Name, 
        List<Character> Characters
        );
}
