package database.jdbc;

import java.sql.SQLException;
import java.util.List;

/**
 * Created by dmitr on 01.04.2018.
 */
public interface Repository<ID, T> {

    List<T> findAll() throws SQLException;

    T findById(ID id);

    boolean insertAll(List<T> entitys);

    boolean insert(T entity);

    boolean update(T entity);

    void remove(ID id);

    void removeAll();
}
