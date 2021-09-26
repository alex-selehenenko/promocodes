﻿using Promocodes.Data.Core.RepositoryInterfaces;
using System;

namespace Promocodes.Data.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ICategoryRepository _categoryRepository;
        private IShopRepository _shopRepository;
        private IOfferRepository _offerRepository;
        private IUserRepository _userRepository;
        private IReviewRepository _reviewRepository;

        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IOfferRepository OfferRepository
        {
            get
            {
                if (_offerRepository is null)
                    _offerRepository = new OfferRepository(_context);

                return _offerRepository;
            }
        }

        public IShopRepository ShopRepository
        {
            get
            {
                if (_shopRepository is null)
                    _shopRepository = new ShopRepository(_context);

                return _shopRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository is null)
                    _userRepository = new UserRepository(_context);

                return _userRepository;
            }
        }

        public IReviewRepository ReviewReposiotry
        {
            get
            {
                if (_reviewRepository is null)
                    _reviewRepository = new ReviewRepository(_context);

                return _reviewRepository;
            }
            
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository is null)
                    _categoryRepository = new CategoryRepository(_context);

                return _categoryRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}