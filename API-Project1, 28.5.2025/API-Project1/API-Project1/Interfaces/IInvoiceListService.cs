﻿using System.Text.Json;
using API_Project1.Entities;
using Microsoft.EntityFrameworkCore;
namespace API_Project1.Interfaces
{
    public interface IInvoiceListService
    {
        Task<string> GetInvoiceListAsync(int currentPage);
        Task<List<string>> GetMaHoaDonListAsync(int currentPage);

        Task SaveListToDatabaseAsync(List<InvoiceListEntity> invoices);

        List<InvoiceListEntity> ConvertJsonToInvoiceList(JsonElement data);

        Task<string> GetDataListAsync(int currentPage);

        Task<List<InvoiceListEntity>> GetFullDataListAsync();
    }
}
