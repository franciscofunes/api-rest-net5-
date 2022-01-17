using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Entities;
using System;
using System.Linq;
using Catalog.Dtos;

namespace Catalog.Controllers
{
  [ApiController]
  [Route("api/items")]
  public class ItemsController : ControllerBase
  {
    private readonly IItemsRepository repository;

    // Dependency injection working on here
    public ItemsController(IItemsRepository repository)
    {
      this.repository = repository;
    }

    // GET api/items
    [HttpGet]
    public IEnumerable<ItemDto> GetItems()
    {
      var items = repository.GetItems().Select(item => item.AsDto());
      return items;
    }

    // GET api/items/{id}
    [HttpGet("{id}")]
    public ActionResult<ItemDto> GetItem(Guid id)
    {
      var item = repository.GetItem(id);

      if (item is null) {
        return NotFound();
      }
      return item.AsDto();
    }

  }


}
