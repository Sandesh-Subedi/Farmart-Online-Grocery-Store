@model IEnumerable<Product>

    <form method="get" action="@Url.Action("Index")">
        <input type="text" name="search" placeholder="Search products..." />
        <button type="submit">Search</button>
    </form>
    
    <table>
        <tr>
            <th>Name</th>
            <th>Description</th>
            <th>Price</th>
        </tr>
        @foreach (var product in Model)
        {
            <tr>
                <td>@product.Name</td>
                <td>@product.Description</td>
                <td>@product.Price</td>
            </tr>
        }
    </table>
    
