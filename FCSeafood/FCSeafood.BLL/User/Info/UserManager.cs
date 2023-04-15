using FCSeafood.BLL.User.Info.Helpers;
using FCSeafood.BLL.User.Info.Models.Params;
using FCSeafood.BLL.User.Info.Models.Response;
using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.User.Info;

public class UserManager {
    private readonly ILogger log = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(UserManager));

    private readonly UserRepository _userRepository;
    private readonly UserMapperHelper _userMapperHelper;

    public UserManager(UserRepository userRepository, UserMapperHelper userMapperHelper) {
        _userRepository = userRepository;
        _userMapperHelper = userMapperHelper;
    }

    public async Task<GetUserResponse> GetUser(GetUserParams getUserParams) {
        try {
            var user = await _userRepository.GetByIdAsync(getUserParams.Id);
            if (user is null) return new GetUserResponse(false, "The user is not defined", null);

            var userModel = await _userMapperHelper.ToModelAsync(user);
            return new GetUserResponse(true, "", userModel);
        } catch (Exception ex) {
            log.LogError($"Failed to get user;\r\nUser Id: [{getUserParams.Id}]\r\nError: [{ex.Message}]");
            return new GetUserResponse(false, "The user is not defined", null);
        }
    }
}