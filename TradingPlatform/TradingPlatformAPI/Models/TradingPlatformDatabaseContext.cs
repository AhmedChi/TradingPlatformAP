using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TradingPlatformAPI.Models
{
    public partial class TradingPlatformDatabaseContext : DbContext
    {
        public TradingPlatformDatabaseContext()
        {
        }

        public TradingPlatformDatabaseContext(DbContextOptions<TradingPlatformDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<CashAccounts> CashAccounts { get; set; }
        public virtual DbSet<Counterparties> Counterparties { get; set; }
        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<Equities> Equities { get; set; }
        public virtual DbSet<EquityTrades> EquityTrades { get; set; }
        public virtual DbSet<FxTrades> FxTrades { get; set; }
        public virtual DbSet<Sectors> Sectors { get; set; }
        public virtual DbSet<SecuritiesAccountEquities> SecuritiesAccountEquities { get; set; }
        public virtual DbSet<SecuritiesAccounts> SecuritiesAccounts { get; set; }
        public virtual DbSet<Trades> Trades { get; set; }
        public virtual DbSet<UserAccounts> UserAccounts { get; set; }
        public virtual DbSet<UserGroups> UserGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=TradingPlatformDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("addresses_pkey");

                entity.ToTable("addresses");

                entity.Property(e => e.AddressId)
                    .HasColumnName("addressID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[addresses_addressID_seq])");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnName("address1");

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasColumnName("address2");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city");

                entity.Property(e => e.CounterpartyId).HasColumnName("counterpartyID");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime2(6)");

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasColumnName("postcode");

                entity.HasOne(d => d.Counterparty)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CounterpartyId)
                    .HasConstraintName("address_counterparty");
            });

            modelBuilder.Entity<CashAccounts>(entity =>
            {
                entity.HasKey(e => e.CashAccountId)
                    .HasName("cashAccounts_pkey");

                entity.ToTable("cashAccounts");

                entity.Property(e => e.CashAccountId)
                    .HasColumnName("cashAccountID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[cashAccounts_cashAccountID_seq])");

                entity.Property(e => e.Balance)
                    .HasColumnName("balance")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.CashAccountName)
                    .IsRequired()
                    .HasColumnName("cashAccountName");

                entity.Property(e => e.CashAccountNumber)
                    .IsRequired()
                    .HasColumnName("cashAccountNumber");

                entity.Property(e => e.CashAccountSortCode)
                    .IsRequired()
                    .HasColumnName("cashAccountSortCode");

                entity.Property(e => e.CounterpartyId).HasColumnName("counterpartyID");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime2(6)");

                entity.HasOne(d => d.Counterparty)
                    .WithMany(p => p.CashAccounts)
                    .HasForeignKey(d => d.CounterpartyId)
                    .HasConstraintName("cashAccount_counterparty");
            });

            modelBuilder.Entity<Counterparties>(entity =>
            {
                entity.HasKey(e => e.CounterpartyId)
                    .HasName("counterparties_pkey");

                entity.ToTable("counterparties");

                entity.Property(e => e.CounterpartyId)
                    .HasColumnName("counterpartyID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[counterparties_counterpartyID_seq])");

                entity.Property(e => e.CounterpartyAddressId).HasColumnName("counterpartyAddressID");

                entity.Property(e => e.CounterpartyEmail)
                    .IsRequired()
                    .HasColumnName("counterpartyEmail");

                entity.Property(e => e.CounterpartyName)
                    .IsRequired()
                    .HasColumnName("counterpartyName");

                entity.Property(e => e.CounterpartyPhone)
                    .IsRequired()
                    .HasColumnName("counterpartyPhone");

                entity.Property(e => e.CounterpartyWebsite)
                    .IsRequired()
                    .HasColumnName("counterpartyWebsite");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime2(6)");

                entity.Property(e => e.IsOwnCompany).HasColumnName("isOwnCompany");

                entity.Property(e => e.ParentCounterpartyId).HasColumnName("parentCounterpartyID");

                entity.Property(e => e.SectorId).HasColumnName("sectorID");

                entity.HasOne(d => d.ParentCounterparty)
                    .WithMany(p => p.InverseParentCounterparty)
                    .HasForeignKey(d => d.ParentCounterpartyId)
                    .HasConstraintName("counterparty_parentCounterparty");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Counterparties)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("counterparty_sector");
            });

            modelBuilder.Entity<Currencies>(entity =>
            {
                entity.HasKey(e => e.CurrencyId)
                    .HasName("currencies_pkey");

                entity.ToTable("currencies");

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("currencyID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[currencies_currencyID_seq])");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime2(6)");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasColumnName("currencyCode");

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasColumnName("currencyName");
            });

            modelBuilder.Entity<Equities>(entity =>
            {
                entity.HasKey(e => e.EquityId)
                    .HasName("equities_pkey");

                entity.ToTable("equities");

                entity.Property(e => e.EquityId)
                    .HasColumnName("equityID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[equities_equityID_seq])");

                entity.Property(e => e.CounterpartyId).HasColumnName("counterpartyID");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime2(6)");

                entity.Property(e => e.CurrencyId).HasColumnName("currencyID");

                entity.Property(e => e.EquityCode)
                    .IsRequired()
                    .HasColumnName("equityCode");

                entity.Property(e => e.EquityName)
                    .IsRequired()
                    .HasColumnName("equityName");

                entity.Property(e => e.EquityPrice)
                    .HasColumnName("equityPrice")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.EquityVariance)
                    .HasColumnName("equityVariance")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.SectorId).HasColumnName("sectorID");

                entity.HasOne(d => d.Counterparty)
                    .WithMany(p => p.Equities)
                    .HasForeignKey(d => d.CounterpartyId)
                    .HasConstraintName("equity_counterparty");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Equities)
                    .HasForeignKey(d => d.SectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("equity_sector");
            });

            modelBuilder.Entity<EquityTrades>(entity =>
            {
                entity.HasKey(e => e.EquityTradeId)
                    .HasName("equityTrades_pkey");

                entity.ToTable("equityTrades");

                entity.Property(e => e.EquityTradeId)
                    .HasColumnName("equityTradeID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[equityTrades_equityTradeID_seq])");

                entity.Property(e => e.CurrencyId).HasColumnName("currencyID");

                entity.Property(e => e.EquityId).HasColumnName("equityID");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.EquityTrades)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("equityTrade_currency");

                entity.HasOne(d => d.Equity)
                    .WithMany(p => p.EquityTrades)
                    .HasForeignKey(d => d.EquityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("equityTrade_equity");
            });

            modelBuilder.Entity<FxTrades>(entity =>
            {
                entity.HasKey(e => e.FxTradeId)
                    .HasName("fxTrades_pkey");

                entity.ToTable("fxTrades");

                entity.Property(e => e.FxTradeId)
                    .HasColumnName("fxTradeID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[fxTrades_fxTradeID_seq])");

                entity.Property(e => e.BaseCurrencyId).HasColumnName("baseCurrencyID");

                entity.Property(e => e.BaseNominal)
                    .HasColumnName("baseNominal")
                    .HasColumnType("numeric(10, 4)");

                entity.Property(e => e.BaseQuotation).HasColumnName("baseQuotation");

                entity.Property(e => e.UnderlyingCurrencyId).HasColumnName("underlyingCurrencyID");

                entity.Property(e => e.UnderlyingNominal)
                    .HasColumnName("underlyingNominal")
                    .HasColumnType("numeric(10, 4)");

                entity.HasOne(d => d.BaseCurrency)
                    .WithMany(p => p.FxTradesBaseCurrency)
                    .HasForeignKey(d => d.BaseCurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fxTrade_baseCurrency");

                entity.HasOne(d => d.UnderlyingCurrency)
                    .WithMany(p => p.FxTradesUnderlyingCurrency)
                    .HasForeignKey(d => d.UnderlyingCurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fxTrade_underlyingCurrency");
            });

            modelBuilder.Entity<Sectors>(entity =>
            {
                entity.HasKey(e => e.SectorId)
                    .HasName("sectors_pkey");

                entity.ToTable("sectors");

                entity.Property(e => e.SectorId)
                    .HasColumnName("sectorID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[sectors_sectorID_seq])");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime2(6)");

                entity.Property(e => e.SectorName)
                    .IsRequired()
                    .HasColumnName("sectorName");
            });

            modelBuilder.Entity<SecuritiesAccountEquities>(entity =>
            {
                entity.HasKey(e => e.SecuritiesAccountEquityId)
                    .HasName("securitiesAccountEquities_pkey");

                entity.ToTable("securitiesAccountEquities");

                entity.Property(e => e.SecuritiesAccountEquityId)
                    .HasColumnName("securitiesAccountEquityID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[securitiesAccountEquities_securitiesAccountEquityID_seq])");

                entity.Property(e => e.CounterpartyId).HasColumnName("counterpartyID");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime2(6)");

                entity.Property(e => e.EquityId).HasColumnName("equityID");

                entity.Property(e => e.SecuritiesAccountId).HasColumnName("securitiesAccountID");

                entity.Property(e => e.SecuritiesQuantity)
                    .HasColumnName("securitiesQuantity")
                    .HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.Counterparty)
                    .WithMany(p => p.SecuritiesAccountEquities)
                    .HasForeignKey(d => d.CounterpartyId)
                    .HasConstraintName("securitesAccountEquitity_counterparty");

                entity.HasOne(d => d.Equity)
                    .WithMany(p => p.SecuritiesAccountEquities)
                    .HasForeignKey(d => d.EquityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("securitesAccountEquitity_equities");
            });

            modelBuilder.Entity<SecuritiesAccounts>(entity =>
            {
                entity.HasKey(e => e.SecurityAccountId)
                    .HasName("securitiesAccounts_pkey");

                entity.ToTable("securitiesAccounts");

                entity.Property(e => e.SecurityAccountId)
                    .HasColumnName("securityAccountID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[securitiesAccounts_securityAccountID_seq])");

                entity.Property(e => e.CounterpartyId).HasColumnName("counterpartyID");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime2(6)");

                entity.Property(e => e.SecurityAccountName)
                    .IsRequired()
                    .HasColumnName("securityAccountName");

                entity.Property(e => e.SecurityAccountNumber)
                    .IsRequired()
                    .HasColumnName("securityAccountNumber");

                entity.Property(e => e.SecurityAccountSortCode)
                    .IsRequired()
                    .HasColumnName("securityAccountSortCode");

                entity.HasOne(d => d.Counterparty)
                    .WithMany(p => p.SecuritiesAccounts)
                    .HasForeignKey(d => d.CounterpartyId)
                    .HasConstraintName("securitesAccount_counterparty");
            });

            modelBuilder.Entity<Trades>(entity =>
            {
                entity.HasKey(e => e.TradeId)
                    .HasName("trades_pkey");

                entity.ToTable("trades");

                entity.Property(e => e.TradeId)
                    .HasColumnName("tradeID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[trades_tradeID_seq])");

                entity.Property(e => e.Buy).HasColumnName("buy");

                entity.Property(e => e.CounterpartyCashAccountId).HasColumnName("counterpartyCashAccountID");

                entity.Property(e => e.CounterpartyId).HasColumnName("counterpartyID");

                entity.Property(e => e.CounterpartySecurityAccountId).HasColumnName("counterpartySecurityAccountID");

                entity.Property(e => e.DealPrice)
                    .HasColumnName("dealPrice")
                    .HasColumnType("numeric(10, 4)");

                entity.Property(e => e.EquityTradeId).HasColumnName("equityTradeID");

                entity.Property(e => e.FxTradeId).HasColumnName("fxTradeID");

                entity.Property(e => e.TradeCashAccountId).HasColumnName("tradeCashAccountID");

                entity.Property(e => e.TradeDate)
                    .HasColumnName("tradeDate")
                    .HasColumnType("datetime2(6)");

                entity.Property(e => e.TradeQuantity).HasColumnName("tradeQuantity");

                entity.Property(e => e.TradeSecurityAccountId).HasColumnName("tradeSecurityAccountID");

                entity.Property(e => e.TradeTotal)
                    .HasColumnName("tradeTotal")
                    .HasColumnType("numeric(16, 4)");

                entity.Property(e => e.UserAccountId).HasColumnName("userAccountID");

                entity.HasOne(d => d.CounterpartyCashAccount)
                    .WithMany(p => p.TradesCounterpartyCashAccount)
                    .HasForeignKey(d => d.CounterpartyCashAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trade_counterpartyCashAccount");

                entity.HasOne(d => d.Counterparty)
                    .WithMany(p => p.Trades)
                    .HasForeignKey(d => d.CounterpartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trade_counterparty");

                entity.HasOne(d => d.CounterpartySecurityAccount)
                    .WithMany(p => p.TradesCounterpartySecurityAccount)
                    .HasForeignKey(d => d.CounterpartySecurityAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trade_counterpartySecurityAccount");

                entity.HasOne(d => d.EquityTrade)
                    .WithMany(p => p.Trades)
                    .HasForeignKey(d => d.EquityTradeId)
                    .HasConstraintName("trade_equityID");

                entity.HasOne(d => d.FxTrade)
                    .WithMany(p => p.Trades)
                    .HasForeignKey(d => d.FxTradeId)
                    .HasConstraintName("trade_fxID");

                entity.HasOne(d => d.TradeCashAccount)
                    .WithMany(p => p.TradesTradeCashAccount)
                    .HasForeignKey(d => d.TradeCashAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trade_tradeCashAccount");

                entity.HasOne(d => d.TradeSecurityAccount)
                    .WithMany(p => p.TradesTradeSecurityAccount)
                    .HasForeignKey(d => d.TradeSecurityAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trade_tradeSecurityAccount");

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.Trades)
                    .HasForeignKey(d => d.UserAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trade_userAccount");
            });

            modelBuilder.Entity<UserAccounts>(entity =>
            {
                entity.HasKey(e => e.UserAccountId)
                    .HasName("userAccounts_pkey");

                entity.ToTable("userAccounts");

                entity.HasIndex(e => e.UserEmail)
                    .HasName("userAccounts_userEmail_key")
                    .IsUnique();

                entity.Property(e => e.UserAccountId)
                    .HasColumnName("userAccountID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[userAccounts_userAccountID_seq])");

                entity.Property(e => e.CounterpartyId).HasColumnName("counterpartyID");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime2(6)");

                entity.Property(e => e.SecurityAnswer)
                    .IsRequired()
                    .HasColumnName("securityAnswer");

                entity.Property(e => e.SecurityQuestion)
                    .IsRequired()
                    .HasColumnName("securityQuestion");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("userEmail");

                entity.Property(e => e.UserGroupId).HasColumnName("userGroupID");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("userPassword");

                entity.HasOne(d => d.Counterparty)
                    .WithMany(p => p.UserAccounts)
                    .HasForeignKey(d => d.CounterpartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userAccount_counterparty");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.UserAccounts)
                    .HasForeignKey(d => d.UserGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userAccount_userGroup");
            });

            modelBuilder.Entity<UserGroups>(entity =>
            {
                entity.HasKey(e => e.UserGroupId)
                    .HasName("userGroups_pkey");

                entity.ToTable("userGroups");

                entity.Property(e => e.UserGroupId)
                    .HasColumnName("userGroupID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [dbo].[userGroups_userGroupID_seq])");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime2(6)");

                entity.Property(e => e.UserGroupName)
                    .IsRequired()
                    .HasColumnName("userGroupName");
            });

            modelBuilder.HasSequence("addresses_addressID_seq").HasMin(1);

            modelBuilder.HasSequence("cashAccounts_cashAccountID_seq").HasMin(1);

            modelBuilder.HasSequence("counterparties_counterpartyID_seq").HasMin(1);

            modelBuilder.HasSequence("currencies_currencyID_seq").HasMin(1);

            modelBuilder.HasSequence("eodpositions_eodpositionID_seq").HasMin(1);

            modelBuilder.HasSequence("equities_equityID_seq").HasMin(1);

            modelBuilder.HasSequence("equityTrades_equityTradeID_seq").HasMin(1);

            modelBuilder.HasSequence("fxTrades_fxTradeID_seq").HasMin(1);

            modelBuilder.HasSequence("sectors_sectorID_seq").HasMin(1);

            modelBuilder.HasSequence("securitiesAccountEquities_securitiesAccountEquityID_seq").HasMin(1);

            modelBuilder.HasSequence("securitiesAccounts_securityAccountID_seq").HasMin(1);

            modelBuilder.HasSequence("trades_tradeID_seq").HasMin(1);

            modelBuilder.HasSequence("userAccounts_userAccountID_seq").HasMin(1);

            modelBuilder.HasSequence("userGroups_userGroupID_seq").HasMin(1);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
