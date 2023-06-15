﻿using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponAPI.Model.Context
{
	public class MySQLContext : DbContext
	{
		public MySQLContext() { }
		public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

		public DbSet<Coupon> Coupons { get; set; }
	}
}