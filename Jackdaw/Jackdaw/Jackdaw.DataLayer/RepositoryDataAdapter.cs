using System;
using System.Collections.Generic;
using System.Text;

namespace Jackdaw.DataLayer
{
    public interface IRepositoryDataAdapter
    {
        IRepository<DirContest> DirContests
        {
            get;
        }

        IRepository<DirNomination> DirNominations
        {
            get;
        }

        IRepository<Institution> Institutions
        {
            get;
        }

        IRepository<Participant> Participants
        {
            get;
        }

        IRepository<RegisteredContest> RegisteredContests
        {
            get;
        }

        IRepository<RegisteredParticipant> RegisteredParticipants
        {
            get;
        }
    }
    
    public class RepositoryDataAdapter : IRepositoryDataAdapter
    {
        private JackdawDbContext _context;
        private IRepository<DirContest> _dirContestRepository;
        private IRepository<DirNomination> _dirNominationRepository;
        private IRepository<Institution> _institutionRepository;
        private IRepository<Participant> _participantRepository;
        private IRepository<RegisteredContest> _registeredContestRepository;
        private IRepository<RegisteredParticipant> _registeredParticipantRepository;

        public RepositoryDataAdapter()
        {
            _context = new JackdawDbContext();
        }

        public IRepository<DirContest> DirContests
        {
            get
            {
                if (_dirContestRepository == null)
                    _dirContestRepository = new Repository<DirContest>(_context);
                return _dirContestRepository;
            }
        }

        public IRepository<DirNomination> DirNominations
        {
            get
            {
                if (_dirNominationRepository == null)
                    _dirNominationRepository = new Repository<DirNomination>(_context);
                return _dirNominationRepository;
            }
        }

        public IRepository<Institution> Institutions
        {
            get
            {
                if (_institutionRepository == null)
                    _institutionRepository = new Repository<Institution>(_context);
                return _institutionRepository;
            }
        }

        public IRepository<Participant> Participants
        {
            get
            {
                if (_participantRepository == null)
                    _participantRepository = new Repository<Participant>(_context);
                return _participantRepository;
            }
        }

        public IRepository<RegisteredContest> RegisteredContests
        {
            get
            {
                if (_registeredContestRepository == null)
                    _registeredContestRepository = new Repository<RegisteredContest>(_context);
                return _registeredContestRepository;
            }
        }

        public IRepository<RegisteredParticipant> RegisteredParticipants
        {
            get
            {
                if (_registeredParticipantRepository == null)
                    _registeredParticipantRepository = new Repository<RegisteredParticipant>(_context);
                return _registeredParticipantRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
