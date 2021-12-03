

using WemaMobileEmployeeService.Models;

namespace WemaMobileEmployeeService.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        protected WemaMobileTrainingContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BaseRepository(WemaMobileTrainingContext context)
        {
            _context = context;
        }
    }
}
